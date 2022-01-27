using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Text
{
    public static class EncodingSpanExtensions
    {
        public static int GetByteCount(this Encoding @this, ReadOnlySpan<char> chars)
        {
            unsafe
            {
                return @this.GetByteCount((char*)Unsafe.AsPointer(ref MemoryMarshal.GetReference(chars)), chars.Length);
            }
        }

        public static int GetBytes(this Encoding @this, ReadOnlySpan<char> chars, Span<byte> bytes)
        {
            unsafe
            {
                return @this.GetBytes(
                    (char*)Unsafe.AsPointer(ref MemoryMarshal.GetReference(chars)),
                    chars.Length,
                    (byte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference(bytes)),
                    bytes.Length
                );
            }
        }

        public static int GetCharCount(this Encoding @this, ReadOnlySpan<byte> bytes)
        {
            unsafe
            {
                return @this.GetCharCount((byte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference(bytes)), bytes.Length);
            }
        }

        public static int GetChars(this Encoding @this, ReadOnlySpan<byte> bytes, Span<char> chars)
        {
            unsafe
            {
                return @this.GetChars(
                    (byte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference(bytes)),
                    bytes.Length,
                    (char*)Unsafe.AsPointer(ref MemoryMarshal.GetReference(chars)),
                    chars.Length
                );
            }
        }
        public static string GetString(this Encoding @this, ReadOnlySpan<byte> bytes)
        {
            unsafe
            {
                return @this.GetString((byte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference(bytes)), bytes.Length);
            }
        }
    }
}
